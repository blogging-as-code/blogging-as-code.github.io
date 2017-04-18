#addin nuget:?package=Cake.Git
#addin nuget:?package=Cake.Kudu
#addin nuget:?package=Cake.Wyam
#tool nuget:?package=Wyam
#tool nuget:?package=KuduSync.NET&version=1.3.1

var deployToken = Argument("DeployToken", EnvironmentVariable("WYAM_DEPLOY_TOKEN"));
var deployRemote = Argument("DeployRemote", EnvironmentVariable("WYAM_DEPLOY_REMOTE"));
var publishFolder = "./publish";
var target = Argument("Target", "Default");

Task("Default");

Task("Clean")
    .Does(() =>
{
    if(DirectoryExists(publishFolder)) {
        DeleteDirectory(publishFolder, recursive:true);
    }
});

Task("Preview")
  .Does(() =>
{
  Wyam(new WyamSettings {
    Preview = true,
    Watch = true,
    InputPaths = new [] { new DirectoryPath("input") }
  });
});

Task("Generate")
  .IsDependentOn("Clean")
  .Does(() =>
{
  Wyam(new WyamSettings {
    Preview = false,
    Watch = false,
    InputPaths = new [] { new DirectoryPath("input") }
  });
});

Task("Publish")
  .IsDependentOn("Generate")
  .Does(() =>
{
  // Get the SHA from the current commit to use in the message for the commit to master
  var sourceCommit = GitLogTip("./");

  // Clone the repository into the publish folder
  GitClone(deployRemote, publishFolder, new GitCloneSettings { BranchName = "master" });

  // Synchronize the output folder with the master branch
  Kudu.Sync("./output", publishFolder, new KuduSyncSettings { ArgumentCustomization = args=>args.Append("--ignore").AppendQuoted(".git;CNAME") });

  // If there are changes...
  if (GitHasUncommitedChanges(publishFolder))
    {
        // Add all changes...
        GitAddAll(publishFolder);

        // And commit them
        GitCommit(
            publishFolder,
            sourceCommit.Committer.Name,
            sourceCommit.Committer.Email,
            string.Format("AppVeyor Publish: {0}\r\n{1}", sourceCommit.Sha, sourceCommit.Message)
        );

        // Finally, push them to the repository
        GitPush(publishFolder, deployToken, "x-oauth-basic", "master");
    }
});

RunTarget(target);
