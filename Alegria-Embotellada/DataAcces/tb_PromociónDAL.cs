﻿using DataAcces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class tb_PromociónDAL
    {
        #region Vizaualizar Promoción
        public static DataTable VizualisarPromocion()
        {
            //Creando el DataTable
            DataTable dtPromociones = new DataTable();

            //Añadiendo las columnas que llevara el DataTable
            dtPromociones.Columns.Add("Descripcion", typeof(string));
            dtPromociones.Columns.Add("Precio", typeof(string));
            dtPromociones.Columns.Add("Marca", typeof(string));
            dtPromociones.Columns.Add("Dia inicial", typeof(string));
            dtPromociones.Columns.Add("Dia final", typeof(string));
            dtPromociones.Columns.Add("Sucrusal", typeof(string));
            dtPromociones.Columns.Add("Colonia", typeof(string));
            dtPromociones.Columns.Add("Calle", typeof(string));
            dtPromociones.Columns.Add("Numero", typeof(string));
            dtPromociones.Columns.Add("Municipio", typeof(string));

            using (AlegriaEmbotelladaEntities bd = new AlegriaEmbotelladaEntities())
            {
                var query = (from p in bd.tb_Promoción
                             join s in bd.tb_Sucursal
                             on p.PK_Promoción equals s.FK_Promoción
                             join art in bd.tb_Artículo
                             on p.FK_Artículo equals art.PK_Artículo
                             select new
                             {
                                 Descripcion = p.Descripción,
                                 Dia_Inicial = p.Dia_Inicio,
                                 Dia_FInal = p.Dia_Finalización,
                                 Nombre_Sucrusal = s.Nombre_Sucursal,
                                 Colonia = s.Colonia,
                                 Calle = s.Calle,
                                 Numero = s.Número,
                                 Muicipio = s.Municipio_Estado,
                                 Precio = art.Precio,
                                 Marca = art.Marca
                             }).ToList();

                query.ToList().ForEach((p) =>
                query.ToList().ForEach((s) =>
                query.ToList().ForEach((art) =>
                {
                    //Creando una fila en el DataTable
                    DataRow fila = dtPromociones.NewRow();

                    //Columnas que llevara la fila
                    fila.SetField<string>("Descripcion", p.Descripcion);
                    fila.SetField<decimal>("Precio", art.Precio);
                    fila.SetField<string>("Marca", art.Marca);
                    fila.SetField<string>("Dia inicial", p.Dia_Inicial);
                    fila.SetField<string>("Dia final", p.Dia_FInal);
                    fila.SetField<string>("Sucrusal", s.Nombre_Sucrusal);
                    fila.SetField<string>("Colonia", s.Colonia);
                    fila.SetField<string>("Calle", s.Calle);
                    fila.SetField<int>("Numero", s.Numero);
                    fila.SetField<string>("Municipio", s.Muicipio);

                    //Añadir la fila creada al DataTable
                    dtPromociones.Rows.Add(fila);
                })));
            }

            //Regresar el DataTable con la informacion
            return dtPromociones;
        }




        #endregion

        #region Vizaualizar Promoción de filtro
        public static DataTable Vizualisarfiltor(string marca, decimal precio1, decimal precio2, string sucursal)
        {

            //Creando el DataTable
            DataTable dtPromociones = new DataTable();

            //Añadiendo las columnas que llevara el DataTable
            dtPromociones.Columns.Add("Descripcion", typeof(string));
            dtPromociones.Columns.Add("Precio", typeof(string));
            dtPromociones.Columns.Add("Marca", typeof(string));
            dtPromociones.Columns.Add("Dia inicial", typeof(string));
            dtPromociones.Columns.Add("Dia final", typeof(string));
            dtPromociones.Columns.Add("Sucrusal", typeof(string));
            dtPromociones.Columns.Add("Colonia", typeof(string));
            dtPromociones.Columns.Add("Calle", typeof(string));
            dtPromociones.Columns.Add("Numero", typeof(string));
            dtPromociones.Columns.Add("Municipio", typeof(string));

            using (AlegriaEmbotelladaEntities bd = new AlegriaEmbotelladaEntities())
            {
                var query = (from p in bd.tb_Promoción
                             join s in bd.tb_Sucursal
                             on p.PK_Promoción equals s.FK_Promoción
                             join art in bd.tb_Artículo
                             on p.FK_Artículo equals art.PK_Artículo
                             where art.Precio >= precio1 && art.Precio <= precio2
                             where art.Marca == marca
                             where s.Nombre_Sucursal == sucursal 
                             select new
                             {
                                 Descripcion = p.Descripción,
                                 Dia_Inicial = p.Dia_Inicio,
                                 Dia_FInal = p.Dia_Finalización,
                                 Nombre_Sucrusal = s.Nombre_Sucursal,
                                 Colonia = s.Colonia,
                                 Calle = s.Calle,
                                 Numero = s.Número,
                                 Muicipio = s.Municipio_Estado,
                                 Precio = art.Precio,
                                 Marca = art.Marca
                             }).ToList();

                query.ToList().ForEach((p) =>
                query.ToList().ForEach((s) =>
                query.ToList().ForEach((art) =>
                {
                //Creando una fila en el DataTable
                DataRow fila = dtPromociones.NewRow();

                //Columnas que llevara la fila
                fila.SetField<string>("Descripcion", p.Descripcion);
                    fila.SetField<decimal>("Precio", art.Precio);
                    fila.SetField<string>("Marca", art.Marca);
                    fila.SetField<string>("Dia inicial", p.Dia_Inicial);
                    fila.SetField<string>("Dia final", p.Dia_FInal);
                    fila.SetField<string>("Sucrusal", s.Nombre_Sucrusal);
                    fila.SetField<string>("Colonia", s.Colonia);
                    fila.SetField<string>("Calle", s.Calle);
                    fila.SetField<int>("Numero", s.Numero);
                    fila.SetField<string>("Municipio", s.Muicipio);

                //Añadir la fila creada al DataTable
                dtPromociones.Rows.Add(fila);
                })));
            }

            //Regresar el DataTable con la informacion
            return dtPromociones;
        }

        #endregion
    }
}

