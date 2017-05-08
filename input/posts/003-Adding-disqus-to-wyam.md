title: Adding Disqus to your Wyam blog
published: 01-05-2017
Tags:
 - wyam
 - disqus
 - tooling
 - how-to
---
## Interaction should be encouraged
That's what I want to achieve with this blog. I'm a big fan of the collaborative way of working you tend to fall into when working with GitHub, and love the usage of chat tools such as Gitter or Slack. However, for a blog these tools are overkill.

Blogs, since the time of their inception, have had some way of commenting on the content. Initially built-in to the framework you use, but for the past few years this has been delegated to a third party service, usually [Disqus][0].

You implement Disqus by embedding a small piece of JavaScript into the markup of your page, which loads the comments from Disqus as well as the controls to leave a comment.

## Add it to your blog!
Implementing this using Wyam is quite simple. The theme system uses Razor, consisting of several views and partials. One of them, the `_PostFooter.cshtml` partial, is appended to the end of each post. This is exactly where you would expect a comments section to show up, so that's an excellent starting point.

The [Disqus documentation][1] for embedding into any HTML page is quite clear. Stripping out all unnecessary parts and comments, we end up with the following `_PostFooter.cshtml`:

```razor
<div id="disqus_thread"></div>
<script>

var disqus_config = function () {
  @* Use the full path as the ID *@
  this.page.identifier = '@Model.FilePath(Keys.RelativeFilePath).FileNameWithoutExtension.FullPath';
};

(function() { // DON'T EDIT BELOW THIS LINE
  var d = document, s = d.createElement('script');
  s.src = '[https://[disqus-site-name-here].disqus.com/embed.js]';
  s.setAttribute('data-timestamp', +new Date());
(d.head || d.body).appendChild(s);
})();
</script>
<noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
```

Don't forget to put your disqus site name at the placeholder. That's it. Put this partial view in your input directory, and you're ready to go!

[0]: https://disqus.com
[1]: https://help.disqus.com/customer/portal/articles/472097-universal-embed-code
