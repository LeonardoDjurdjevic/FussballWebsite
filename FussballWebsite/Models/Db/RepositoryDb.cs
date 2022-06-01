using Fussball_Website.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FussballWebsite.Models.DB {

    public class RepositoryDb : IRepositoryDb {
        private string connectionsString = "Server=localhost;database=fussball;user=root";
        private DbConnection connection;

        public async Task ConnectAsync() {
            if (this.connection == null) {
                this.connection = new MySqlConnection(this.connectionsString);
            }
            if (this.connection.State != ConnectionState.Open) {
                await this.connection.OpenAsync();
            }
        }

        public async Task DisconnectAsync() {
            if (this.connection != null && this.connection.State == ConnectionState.Open) {
                await this.connection.CloseAsync();
            }
        }

        public async Task<bool> Insert(User user) {
            if (this.connection?.State == ConnectionState.Open) {
                DbCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "insert into users values(null, @username, sha2(@password, 512), @email, @birthdate, @gender, @liga, @role)";
                DbParameter paramUN = cmd.CreateParameter();
                paramUN.ParameterName = "username";
                paramUN.DbType = System.Data.DbType.String;
                paramUN.Value = user.Username;

                DbParameter paramPW = cmd.CreateParameter();
                paramPW.ParameterName = "password";
                paramPW.DbType = System.Data.DbType.String;
                paramPW.Value = user.Password;

                DbParameter paramEmail = cmd.CreateParameter();
                paramEmail.ParameterName = "email";
                paramEmail.DbType = System.Data.DbType.String;
                paramEmail.Value = user.EMail;

                DbParameter paramBD = cmd.CreateParameter();
                paramBD.ParameterName = "birthdate";
                paramBD.DbType = System.Data.DbType.Date;
                paramBD.Value = user.Birthdate;

                DbParameter paramGender = cmd.CreateParameter();
                paramGender.ParameterName = "gender";
                paramGender.DbType = System.Data.DbType.Int32;
                paramGender.Value = user.Gender;

                DbParameter paramLiga = cmd.CreateParameter();
                paramLiga.ParameterName = "liga";
                paramLiga.DbType = System.Data.DbType.Int32;
                paramLiga.Value = user.Liga;

                DbParameter paramRole = cmd.CreateParameter();
                paramRole.ParameterName = "role";
                paramRole.DbType = System.Data.DbType.Int32;

                if(paramEmail.Value == "ldjurdjevic@tsn.at" || paramEmail.Value == "jkessel@tsn.at" || paramEmail.Value == "meesen@tsn.at") {
                    paramRole.Value = 1;
                } else {
                    paramRole.Value = 0;
                }

                cmd.Parameters.Add(paramUN);
                cmd.Parameters.Add(paramPW);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramBD);
                cmd.Parameters.Add(paramGender);
                cmd.Parameters.Add(paramLiga);
                cmd.Parameters.Add(paramRole);

                return await cmd.ExecuteNonQueryAsync() == 1;
            }
            return false;
        }

        public async Task<bool> Delete(int user_id) {
            if (this.connection?.State == ConnectionState.Open) {
                DbCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "delete from users where user_id = @user_id";
                DbParameter paramID = cmd.CreateParameter();

                paramID.ParameterName = "user_id";
                paramID.DbType = System.Data.DbType.Int32;
                paramID.Value = user_id;

                cmd.Parameters.Add(paramID);
                return await cmd.ExecuteNonQueryAsync() == 1;
            }
            return false;
        }

        public async Task<bool> ChangeUserData(int userID, User user) {
            if (this.connection?.State == ConnectionState.Open) {
                DbCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "update users set username = @username, password = sha2(@password, 512), " +
                    "email = @email, birthdate = @birthdate, gender = @gender, liga = @liga) where user_id = @user_id";
                DbParameter paramID = cmd.CreateParameter();
                paramID.ParameterName = "user_id";
                paramID.DbType = System.Data.DbType.Int32;
                paramID.Value = user.UserID;

                DbParameter paramUN = cmd.CreateParameter();
                paramUN.ParameterName = "username";
                paramUN.DbType = System.Data.DbType.String;
                paramUN.Value = user.Username;

                DbParameter paramPW = cmd.CreateParameter();
                paramPW.ParameterName = "password";
                paramPW.DbType = System.Data.DbType.String;
                paramPW.Value = user.Password;

                DbParameter paramEmail = cmd.CreateParameter();
                paramEmail.ParameterName = "email";
                paramEmail.DbType = System.Data.DbType.String;
                paramEmail.Value = user.EMail;

                DbParameter paramBD = cmd.CreateParameter();
                paramBD.ParameterName = "birthdate";
                paramBD.DbType = System.Data.DbType.Date;
                paramBD.Value = user.Birthdate;

                DbParameter paramGender = cmd.CreateParameter();
                paramGender.ParameterName = "gender";
                paramGender.DbType = System.Data.DbType.Int32;
                paramGender.Value = user.Gender;

                DbParameter paramLiga = cmd.CreateParameter();
                paramLiga.ParameterName = "liga";
                paramLiga.DbType = System.Data.DbType.Int32;
                paramLiga.Value = user.Liga;

                DbParameter paramRole = cmd.CreateParameter();
                paramRole.ParameterName = "role";
                paramRole.DbType = System.Data.DbType.Int32;
                paramRole.Value = user.Liga;

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramUN);
                cmd.Parameters.Add(paramPW);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramBD);
                cmd.Parameters.Add(paramGender);
                cmd.Parameters.Add(paramLiga);
                cmd.Parameters.Add(paramRole);

                return await cmd.ExecuteNonQueryAsync() == 1;
            }
            return false;
        }

        public List<User> GetAllUsers() {
            List<User> users = new List<User>();
            if (this.connection?.State == ConnectionState.Open) {
                DbCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "select * from users";
                using (DbDataReader reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        users.Add(new User() {
                            UserID = Convert.ToInt32(reader["user_id"]),
                            Username = Convert.ToString(reader["username"]),
                            Password = Convert.ToString(reader["password"]),
                            EMail = Convert.ToString(reader["email"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            Gender = (Gender)Convert.ToInt32(reader["gender"]),
                            Liga = (Liga)Convert.ToInt32(reader["liga"]),
                            Role = (Role)Convert.ToInt32(reader["role"])
                        });
                    }
                }
            }
            return users;
        }

        public async Task<User> GetUser(string user_id) {
            User user;
            if (this.connection?.State == ConnectionState.Open) {
                DbCommand cmdGetUser = this.connection.CreateCommand();
                cmdGetUser.CommandText = "select * from users where email=@email or user_id=@user_id;";
                DbParameter paramID = cmdGetUser.CreateParameter();
                paramID.ParameterName = "user_id";
                paramID.DbType = DbType.String;
                int errorCounter = Regex.Matches(user_id, @"[a-zA-Z]").Count;
                String id = "";
                if (errorCounter == 0) {
                    id = user_id;
                }
                paramID.Value = id;

                DbParameter paramEmail = cmdGetUser.CreateParameter();
                paramEmail.ParameterName = "email";
                paramEmail.DbType = DbType.String;
                paramEmail.Value = user_id;
                cmdGetUser.Parameters.Add(paramEmail);
                cmdGetUser.Parameters.Add(paramID);
                using (DbDataReader reader = await cmdGetUser.ExecuteReaderAsync()) {
                    while (await reader.ReadAsync()) {
                        user = new User {
                            UserID = Convert.ToInt32(reader["user_id"]),
                            Username = Convert.ToString(reader["username"]),
                            Password = Convert.ToString(reader["password"]),
                            EMail = Convert.ToString(reader["email"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            Gender = (Gender)Convert.ToInt32(reader["gender"]),
                            Liga = (Liga)Convert.ToInt32(reader["liga"]),
                            Role = (Role)Convert.ToInt32(reader["role"])
                        };
                        return user;
                    }
                }
            }
            return new User();
        }

        public async Task<User> Login(string email, string password) {
            if (this.connection?.State == System.Data.ConnectionState.Open) {
                DbCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "select * from users where email = @email and password = sha2(@password, 512)";

                DbParameter paramEM = cmd.CreateParameter();
                paramEM.ParameterName = "email";
                paramEM.DbType = System.Data.DbType.String;
                paramEM.Value = email;

                DbParameter paramPW = cmd.CreateParameter();
                paramPW.ParameterName = "password";
                paramPW.DbType = System.Data.DbType.String;
                paramPW.Value = password;

                cmd.Parameters.Add(paramEM);
                cmd.Parameters.Add(paramPW);

                using (DbDataReader reader = await cmd.ExecuteReaderAsync()) {
                    if (reader.Read()) {
                        return new User() {
                            UserID = Convert.ToInt32(reader["user_id"]),
                            Username = Convert.ToString(reader["username"]),
                            Password = Convert.ToString(reader["password"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            EMail = Convert.ToString(reader["email"]),
                            Gender = (Gender)Convert.ToInt32(reader["gender"]),
                            Liga = (Liga)Convert.ToInt32(reader["liga"]),
                            Role = (Role)Convert.ToInt32(reader["role"])
                        };
                    }
                }
            }
            return null;
        }

        public async Task<bool> emailAvailable(string email) {
            if (this.connection?.State == ConnectionState.Open) {
                DbCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "select * from users where email = @email;";
                DbParameter paramID = cmd.CreateParameter();

                paramID.ParameterName = "email";
                paramID.DbType = System.Data.DbType.String;
                paramID.Value = email;

                cmd.Parameters.Add(paramID);

                if(await cmd.ExecuteNonQueryAsync() > 0) {
                    return false;
                } else {
                    return true;
                }
            }
            return false;
        }

    }
}