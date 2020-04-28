﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebDemo.Data
{
    public class PeopleRepository
    {
        private readonly string _connectionString;

        public PeopleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using (var context = new PeopleContext(_connectionString))
            {
                return context.People.ToList();
            }
        }

        public void Add(Person person)
        {
            using (var context = new PeopleContext(_connectionString))
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        public Person GetById(int id)
        {
            using (var context = new PeopleContext(_connectionString))
            {
                return context.People.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Update(Person person)
        {
            using (var context = new PeopleContext(_connectionString))
            {
                context.People.Attach(person);
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new PeopleContext(_connectionString))
            {
                context.Database.ExecuteSqlCommand(
                    "DELETE FROM People WHERE Id = @id",
                    new SqlParameter("@id", id));
            }
        }
    }
}
//Create an application where people can upload images for others
//to see and "Like". 

//There should be a page on the site where a user can upload new images.
//What that means is, there should be a big textbox where they can add the
//url of an image from somewhere on the web. If you filter doesn't allow any images,
//maybe you can use one of the images from my website:

//https://lakewoodprogramming.com/images/vs-install/1.jpg
//https://lakewoodprogramming.com/images/vs-install/2.jpg
//https://lakewoodprogramming.com/images/vs-install/3.jpg
//https://lakewoodprogramming.com/images/vs-install/5.jpg
//https://lakewoodprogramming.com/images/vs-install/6.jpg

//On that page, there should also be a textbox where they can add a title for an image.

//On the home page, display a list of all images, sorted by most recent. With each
//image, display the title of that image. The image and title should be links, that
//when clicked, should take the user to a page where they see that individual
//image in large.

//Beneath that image, there should be a button that says "Like". When a user clicks 
//on this button, via ajax, update the likes count in the database. Once a user
//has liked an image, they should not be able to like it again (use cookies/session 
//for this). 

//Next to the Like button, there should be a number that displays the current amount
//of likes for this image. This number should be updated in real time, e.g. if someone
//else on a different machine likes this image, the number should update on my screen
//as well without me having to hit refresh. The way to do this last part is by using
//setInterval. In setInterval, make an ajax call to the server to get the current count
//of likes, and update the page with that number.

/*setInterval(() => {
console.log(Math.floor((Math.random() * 100) + 1));
}, 500)
*/

