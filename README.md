# macrobond-webfilefetcher
 Macrobond WebFileFetcher

 A WebFileFetcher application designed with the base case of abs.gov.au, but with the mind of being able to reuse for other websites and cases.

 Assumptions:
 - Since I didn't find in the Requirements document the output .csv folder or the file name desired, I named it: "Output/output.csv"
    - All this is configurable in the confs.Development.json configuration file
 - All the output folders ("Downloads" and "Output") will be placed near the .sln Solution folder
   - Due to this, the solution was done thinking that the execution of the program will be done with an IDE (Visual Studio), that have executes the program inside the AppDomain Base Directory (meaning that it is expecting that the execution folder it is inside bin/.../).
   - For executions with the .exe output file direct (and the needed .dll files and confs folder), the output folders might be created in unexpected locations.
 - All the output folders does not need to exist before executing the application for the first time.

 Contact:
 - Any problem with the execution of the solution or trouble getting the final output files please contact me.
 - email: diogorebimba@gmail.com

