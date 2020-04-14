---
title: "How to get up and running with Hugo in no time"
date: 2020-04-12T17:05:40+02:00
tags: ["hugo","blogging","howto"]

---

I decided it's time to dust off the ol' blog again, just to have a place to do
the occasional brain dump. And as I'm a big fan of _anything_ as code, I'm using
a static website generator to generate content from a git repository.
Here's what I did to get this blog up and running using [Hugo](https://gohugo.io/).
<!--more-->

## Step 1: Installation

Before you can use any tool you obviously need to install it. I'm using linux,
so I cloned the GitHub repository and ran `go install`. This does require you 
to have Go (>=1.11) installed though!

```
git clone https://github.com/gohugoio/hugo
cd hugo
go install
```

If you're using macOS or Linux you can use Homebrew:
```
brew install hugo
```

Using Windows? That's cool as well. Use Chocolatey!

```
choco install hugo -confirm
```

Or, if you want to install from source, simply clone the repository and run 
`go install`.


## Step 2: Initialize a new site

Next up is to initialize the new hugo website.
 - mkdir
 - cd 
 - hugo new site

 This creates a standard directory layout for hugo

 ## Step 3: Install a theme

 Easy mode:
Go to https://themes.gohugo.io/ and pick one you like. I used
https://themes.gohugo.io/vienna the first time around. Follow the install
instructions! In short: `mkdir themes`, download the theme there.

## Start your local server:

`hugo server --theme <your-theme, vienna in my case> --watch`
