## RAZOR PAGES
Create an App using razor pages that has following features:

1) Introduce simple person model
   - Id
    - Name
2) Use in memory-db (EF)
   - remember to install `Microsoft.EntityFrameworkCore.InMemory` package
   - use customer db context
    - after refreshing data persists
3) Implement CRUD operations with Razor pages
    - List View (index)
    - Add Button
    - Edit View
    - Delete Button

##asp-page
The asp-page attribute is used with Razor Pages. Use it to set an anchor tag's href attribute value to a specific page. Prefixing the page name with a forward slash ("/") creates the URL.

The following sample points to the attendee Razor Page:```<a asp-page="/Attendee">All Attendees</a>```

##asp-route-{value}
The asp-route-{value} attribute enables a wildcard route prefix. Any value occupying the {value} placeholder is interpreted as a potential route parameter. If a default route isn't found, this route prefix is appended to the generated href attribute as a request parameter and value. Otherwise, it's substituted in the route template.
    
## asp-page-handler
The asp-page-handler attribute is used with Razor Pages. It's intended for linking to specific page handlers.
```C#
public void OnGetProfile(int attendeeId)
{
    ViewData["AttendeeId"] = attendeeId;

    // code omitted for brevity
}
```
The page model's associated markup links to the OnGetProfile page handler. Note the On<Verb> prefix of the page handler method name is omitted in the asp-page-handler attribute value. When the method is asynchronous, the Async suffix is omitted, too.
```angular2html
<a asp-page="/Attendee"
   asp-page-handler="Profile"
   asp-route-attendeeid="12">Attendee Profile</a>
```