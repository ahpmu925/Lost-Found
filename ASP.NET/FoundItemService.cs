using LostandFound.Data;
using LostandFound.Data.Interfaces;
using LostandFound.Models.Domain;
using LostandFound.Models.Requests;
using LostandFound.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LostandFound.Services
{
    public class FoundItemService : IFoundItemService
    {
        private IDataProvider _dataProvider;

        public FoundItemService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public int Add(FoundItemAddRequest model, int userId)
        {


            int id = 0;

            Action<SqlParameterCollection> inputParamDelegate = delegate (SqlParameterCollection paramCollection)
            {

                paramCollection.AddWithValue("@Item", model.Item);
                paramCollection.AddWithValue("@Name", model.Name);
                paramCollection.AddWithValue("@Email", model.Email);
                paramCollection.AddWithValue("@PhoneNo", model.PhoneNo);
                paramCollection.AddWithValue("@Location", model.Location);
                paramCollection.AddWithValue("@Description", model.Description);
                paramCollection.AddWithValue("@UserId", userId);

                SqlParameter idParameter = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                idParameter.Direction = System.Data.ParameterDirection.Output;

           
                paramCollection.Add(idParameter);

            };

            Action<SqlParameterCollection> returnParamDelegate = delegate (SqlParameterCollection paramCollection)
            {
                Int32.TryParse(paramCollection["@Id"].Value.ToString(), out id);
            };

            string proc = "dbo.FoundItems_Insert";

            _dataProvider.ExecuteNonQuery(proc, inputParamDelegate, returnParamDelegate);


            return id;


        }

        private static FoundItem MapFoundItem(IDataReader reader)
        {
            FoundItem foundItem = new FoundItem();
            int startingIndex = 0; 

            foundItem.Id = reader.GetSafeInt32(startingIndex++);
            foundItem.Item = reader.GetSafeString(startingIndex++);
            foundItem.Name = reader.GetSafeString(startingIndex++);
            foundItem.Email = reader.GetSafeString(startingIndex++);
            foundItem.PhoneNo = reader.GetSafeString(startingIndex++);
            foundItem.Location = reader.GetSafeString(startingIndex++);
            foundItem.Description = reader.GetSafeString(startingIndex++);
            foundItem.UserId = reader.GetSafeInt32(startingIndex++);

            return foundItem;
        }



        public List<FoundItem> GetAll()
        {
            List<FoundItem> list = null;

            Action<IDataReader, short> singleRecMapper = delegate (IDataReader reader, short set)

                {
                    FoundItem newItem = MapFoundItem(reader);

                    if (list == null)
                    {
                        list = new List<FoundItem>();
                    }
                    list.Add(newItem);
                };

                Action<SqlParameterCollection> inputParamDelegate = null;

                _dataProvider.ExecuteCmd("dbo.FoundItems_SelectAll", inputParamDelegate, singleRecMapper);

                return list;
            }


    }
}



