﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using ChessLibrary;

namespace Persistance
{
    public class LoaderJson : IUserDataManager
    {
        private const string DataDirectory = "..\\\\..\\\\..\\\\.\\\\donneePersistance";
        private const string JsonFileName = "testUser.json";

        public override void writeUsers(List<User> users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            Directory.CreateDirectory(DataDirectory);
            string jsonFilePath = Path.Combine(DataDirectory, JsonFileName);

            var serializer = new DataContractJsonSerializer(typeof(List<User>));

            using (var memoryStream = new MemoryStream())
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(memoryStream, Encoding.UTF8, ownsStream: false, indent: true, indentChars: "  "))
                {
                    serializer.WriteObject(writer, users);
                    writer.Flush();
                }

                File.WriteAllText(jsonFilePath, Encoding.UTF8.GetString(memoryStream.ToArray()));
            }
        }

        public override List<User>? readUsers()
        {
            string jsonFilePath = Path.Combine(DataDirectory, JsonFileName);

            if (!File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException("Le fichier JSON spécifié est introuvable.");
            }

            var serializer = new DataContractJsonSerializer(typeof(List<User>));
            string json = File.ReadAllText(jsonFilePath);

            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                return serializer.ReadObject(memoryStream) as List<User>;
            }
        }
    }
}