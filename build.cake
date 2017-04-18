#addin nuget:?package=Cake.Wyam
#tool nuget:?package=Wyam

var target = Argument("Target", "Default");

Task("Default");

Task("Preview")
  .Does(() =>
{
  Wyam(new WyamSettings {
    Preview = true,
    Watch = true,
    InputPaths = new [] { new DirectoryPath("input") }
  });
});

RunTarget(target);
