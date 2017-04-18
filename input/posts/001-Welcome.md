Title: Welcome to Blogging as Code
Published: 16-04-2017
Tags: Introduction
---
## Welcome!

It's time to reboot the blog, and start publishing my experiences while getting to grips with __infrastructure as code__. I will use this
blog as a way to improve my writing, as well as to structure my thoughts so I can explain the technology in a better way to my colleagues.

## Why this name?

As the infrastructure engineering domain is basically built on the premise of defining every single moving part as a script or template, or _as code_ if you will,
I felt that the first step should be to define my blog as code. As such, the source code of this blog can be found [on GitHub][0]. I hope that this will encourage you,
the reader, to send pull requests for mistakes I make, and add issues if you want me to elaborate on something that I've written before.

## How does it work then?

I've implemented the blog using a static content generator called [Wyam][1], which takes raw Markdown files and turns it into a static HTML website. I'm using [Cake][2] build scripts to orchestrate compiling and publishing. To actually execute these scripts whenever I commit new content to the [GitHub repository][0], I use AppVeyor. AppVeyor calls itself __#1 Continuous Delivery service for Windows__, which basically means it will monitor the repository, and when new content is added runs the Cake scripts and eventually publishes new content to GitHub pages.


[0]: https://github.com/blogging-as-code/blogging-as-code.evision.io
[1]: https://wyam.io/
[2]: http://cakebuild.net/
