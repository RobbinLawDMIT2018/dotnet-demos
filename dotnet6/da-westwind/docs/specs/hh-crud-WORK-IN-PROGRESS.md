# Train Watch - Ex06 - Database CRUD (Create, Read, Update, Delete) or READ (Retrieve, Edit, Add, Delete) Operations

> This is the **fourth** in a series of exercises where you will be building a website to manage information on trains. **Train Watch** is a community site for train lovers who want to keep up-to-date on trains across North America. They want to maintain a database of Engines and RailCars.
>
> **This set is cumulative**; future exercises in this series will build upon previous exercises.

## Overview

In this assignment, your task is to create a single-page form to manage Rolling Stock data. This form will handle all the CRUD or READ operations on the RollingStock table from the TrainWatch database.

Use the demos presented in class as a guide to implementing this exercise.
### Manage Rolling Stock

On the razor page called `Crud` that was created in the previous exercise, create a form that allows the user to enter/edit the information for a row of data from the *RollingStock* table of the *TrainWatch* database. Use an appropriate input control for each field, and be sure to use an appropriate drop-down for editing the foreign key information. Use proper validation so that bad data does not end up in the database.

The page must accept an optional parameter for the reporting mark of the rail car from the `Query` page. 

If the reporting mark IS supplied, then retrieve the data for that particular rail car from the database and fill the form with the existing information on the rail car.

If the reporting mark IS NOT supplied, then present the form with default data (0 for numbers, empty for text, etc.), so the user can change and add the new rail car to the database.
### Update Rail Car

Continue the functionality of the `Crud` page by allowing the user to update existing rail car data in the database. Provide appropriate validation of user input before you update the database.

The update button must use the text "Update". It should only be enabled if a reporting mark parameter has been supplied by the `Query` page.

When handling the post, be sure to report any errors/failures to the user and allow them to continue editing the data in the form. If the update is successful, display a success message to the user and then complete the processing by using the Post-Redirect-Get pattern.

### Add Rail Car

Continue the functionality of the `Crud` page by allowing the user to add a new rail car to the database. Provide appropriate validation of user input before you add to the database.

The add button must use the text "Add" and only be enabled if there is no parameter for the reporting mark sent from the `Query` page.

When handling the post, be sure to report any errors/failures to the user and allow them to continue editing the data the form. If the add is successful, display a success message to the user and then complete the processing by using the Post-Redirect-Get pattern.

### Delete Rail Car

Complete the functionality of the `Crud` page by allowing the user to delete existing rail cars from the database.

The delete button must use the text "Delete". It should only be enabled if the reporting mark parameter has been supplied by the `Query` page.

In addition, the delete button must perform a client-side confirmation using JavaScript before processing the delete.

When handling the post, be sure to report any errors/failures to the user and allow them to continue editing the data on the form. If the delete is successful, redirect the user back to the `Query` page and send a delete success parameter to be displayed to the user on the `Query` page.