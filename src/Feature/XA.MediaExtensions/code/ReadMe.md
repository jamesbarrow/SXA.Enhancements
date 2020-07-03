This is a fix for an issue in Sitecore SXA ImageGallary feature when a CDN is used. 

The gallary renders the main image with a forward slash before the URL, which won't work with a fully qualified domain. 

This checks if the "Media.AlwaysIncludeServerUrl" setting is false. If it is then it will apply the forward slash. 