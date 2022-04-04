# Data Binding with the [BindProperty] annotation

- First of all, remember that whatever model binding strategies anyone tries to create (whether in C#, PHP, etc), it has to build on the way HTTP sends data to the webserver (which is always as name-value pairs).
- Microsoft created a system of model binding that can handle both simple and complex types of data. For POST requests, they have the [BindProperty] attribute which identifies the properties that require model binding to take place. 
- The model binding happens before any OnPost() method occurs. 
- The default model binding depends on the name of the property (and its sub-properties in the case of a complex type) and will examine the incoming name-value pairs for a name to match the property name (case insensitive).
- If a [BindProperty] is used on any collection type (an array, List<T>, etc.), then it will expect some type of indexing to be present in the key-value pairs arriving from the browser. 
- By default, the indexing is expected to start at 0 and increment by 1 for each element in a contiguous fashion. 
- This indexing can be over-ridden by applying our own .Index value as part of the posted name-value pairs (and it would be necessary to use if there are "gaps" in the identifying index or "primary key" values).
- All of this model binding is part of the default model binders that Microsoft created. 
- It's possible to make our own custom model binders for even more complex situations.
- Thus, when the browser sends the data to the web server, the ASP.NET Core default model binding will kick in to match-up the values in our List<T> collections for us.


