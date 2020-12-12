Notes on the code:

1.  Integration tests make web calls out to real google
2.  Unit tests use captured responses read from file, no real http calls
3.  There is an IResultsFetcher interface that has two implementations.  I was swapping them back in forth in the UnityConfig, because I didn't want to keep hitting google
	while iterating during development.  If you hit it too frequently, it will start blocking you.
4.  Made use of knockout.js for client side view binding
5.  I initially pursued using regex for scraping, but settled on just searching the response string looking for specific tokens and patterns.  

Features that I added:

1.  If I was the user of the app, I feel like I'd want to see where my results stood in the context of the rest of the search results.  To that end, I showed all 100 in my UI and     	highlighted the occurrences of our url.

Ideas for enhancements:

1. Provide the ability for the user to include paid ads in the search results
2. Show trends over time.  For example, if your URL of interest appears as #7 in the results today, is that an improvement over it's previous position?  Static snapshots aren't really telling much of a story, I want to know whether we're improving or not.  We would need to add a database to start persisting results.
3. Because scraping sites leaves you at risk of being broken when the site changes the shape of it's data, it would be a good idea to have multiple implementations of your scraper that adhered to a common interface.

