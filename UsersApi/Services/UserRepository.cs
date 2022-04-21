using UsersApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Configuration;

namespace UsersApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _usersCollection;
        private UserDatabaseSettings userDbSettings { get; set; }

        IOptions<UserDatabaseSettings> userDatabaseSettings;
        public UserRepository(IOptions<UserDatabaseSettings> settings)
        {
            userDbSettings = settings.Value;
          
            var mongoClient = new MongoClient(
             userDbSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(
               userDbSettings.DatabaseName);
           _usersCollection = mongoDatabase.GetCollection<User>(
                userDbSettings.UsersCollectionName);
            
        }
        public List<User> GetAllUser()
         {
            return _usersCollection.Find(User => true).ToList();
        }
        public User GetUser(int id)
        {
           try
            {
                return _usersCollection.Find<User>(user => user.Id == id).FirstOrDefault();
            }
            catch(Exception ex)
            {
                var obj = ex.ToString();
            }
            return null;
           
        }
       
        public User Create(User user)
        {
           _usersCollection.InsertOne(user);
           return user;
        }
        public void Update(int id,User userIn)
        {
            _usersCollection.ReplaceOne(user => user.Id == id, userIn);
        }
        public void Remove( User userIn)
        {
            _usersCollection.DeleteOne(user => user.Id ==userIn.Id);

        }
       
    }
}

