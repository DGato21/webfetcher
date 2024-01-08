# webfilefetcher
 WebFileFetcher

A WebFileFetcher application designed with the intent to be able to fetch, in a generic way, APIs and Website content from sections to files available in sections.
All this is intent to be done in a configurable way, manipulating a JSON configuration file in a way that indicates the URLs, endpoints or even the HTML sections of a website that are intent to be fetched.
You can also set an set of steps to fetch an HTML site and navigate through web pages using the WebsiteAutoConfiguration that allow to set a serious of "steps" and sections to sniff in order to go to another page and download or get an HTML.

Base Case Study:
- This application was designed with the base case of abs.gov.au, but with the mind of being able to reuse for other websites and cases.

 Assumptions:
 - All the output folders ("Downloads" and "Output") will be placed near the .sln Solution folder
   - Due to this, the solution was done thinking that the execution of the program will be done with an IDE (Visual Studio), that have executes the program inside the AppDomain Base Directory (meaning that it is expecting that the execution folder it is inside bin/.../).
   - For executions with the .exe output file direct (and the needed .dll files and confs folder), the output folders might be created in unexpected locations.
 - All the output folders does not need to exist before executing the application for the first time.

 Contact:
 - Any problem with the execution of the solution or trouble getting the final output files please contact me.
 - email: diogorebimba@gmail.com

