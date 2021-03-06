﻿using DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class tb_LoginBAL
    {
        #region ingresar datos
        public static string MensajesIngresarDatos(tb_Login login)
        {
            string mensaje = "";
            bool isInsert = false;

            if (ConnecionDAL.ConnectToSql())
            {
                mensaje = "No hay Conexión ";
            }
            else
            {
                isInsert = tb_LoginDAL.IngresarDatos(login);
                //Validación para insertar Datos de Login

                if (isInsert)
                {
                    mensaje = "";
                }
                else
                {
                    mensaje = "¡ATENCIÓN! algunos de los campos ya existe. Favor de introducir uno distinto.";
                }
            }

            return mensaje;

        }

       
        #endregion

        #region Validar PasswordyUser del Login
        public static string usauarioExiste(string pass, string user)
        {
            string mensaje = "";
            bool isExiste = false;
            if (ConnecionDAL.ConnectToSql())
            {
                mensaje = "No hay Conexión";
            }
            else
            {
                //Validación si los campos viene vaciós
                if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                {
                    mensaje = "Existen campos vacios, Favor de introducir usuarito y/o constraña";
                }
                else
                {
                    isExiste = tb_LoginDAL.validarPasswordyNameNick(pass, user);
                    //Validación si exixten los campos en el Login
                    if (isExiste)
                    {
                        mensaje = "";
                    }
                    else
                    {
                        mensaje = "El usuario no existe o los datos son incorrectos. Favor de verificarlo. ";
                    }
                }
            }

            return mensaje;
        }
        #endregion

        #region Validar PasswordyUser del Formulario
        public static string usauarioExisteformu(string pass, string user)
        {
            string mensaje = "";
            bool isExiste = false;
            if (ConnecionDAL.ConnectToSql())
            {
                mensaje = "No hay Conexión";
            }
            else
            {      
                    //Validación para si Los campos no estan vaciós
                     //Validación si  Existen los campos en el Formulario
                        isExiste = tb_LoginDAL.validarPasswordyNameNickFormulario(pass, user);

                        if (isExiste)
                        {
                            mensaje = "El nombre de usuario ya existe. Favor de introducir uno distinto.";
                        }
                        else
                        {
                            mensaje = "";
                        }  
            }
            return mensaje;
        }
       
        #endregion

        #region Modificar Login
        public static bool ModificarLogin(tb_Login login)
        {
            return tb_LoginDAL.ModificarLogin(login);
        }
        #endregion
    }
}
