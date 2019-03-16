﻿using Core.Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.General
{
    public class Categoria_Data
    {
        public List<Categoria_Info> GetList(bool mostrar_anulados)
        {
            try
            {
                List<Categoria_Info> Lista;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    if(mostrar_anulados)
                    {
                        Lista = db.Categoria.Select(q => new Categoria_Info
                        {
                            ca_Codigo = q.ca_Codigo,
                            ca_Descripcion = q.ca_Descripcion,
                            ca_Estado = q.ca_Estado,
                            IdCategoria = q.IdCategoria

                        }).ToList();
                    }
                    else
                    {
                        Lista = db.Categoria.Where(q=>q.ca_Estado == true).Select(q => new Categoria_Info
                        {
                            ca_Codigo = q.ca_Codigo,
                            ca_Descripcion = q.ca_Descripcion,
                            ca_Estado = q.ca_Estado,
                            IdCategoria = q.IdCategoria

                        }).ToList();
                    }
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Categoria_Info GetInfo (int IdCategoria)
        {
            try
            {
                Categoria_Info info = new Categoria_Info();
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Categoria Entity = db.Categoria.Where(q => q.IdCategoria == IdCategoria).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new Categoria_Info
                    {
                        IdCategoria = Entity.IdCategoria,
                        ca_Codigo = Entity.ca_Codigo,
                        ca_Descripcion = Entity.ca_Descripcion,
                        ca_Estado= Entity.ca_Estado
                    };

                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetId()
        {
            try
            {
                int Id = 1;
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    var lst = from q in db.Categoria
                              select q;
                    if (lst.Count() > 0)
                        Id = lst.Max(q => q.IdCategoria) + 1;
                }
                return Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GuardarDB(Categoria_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    db.Categoria.Add(new Categoria
                    {
                        IdCategoria = info.IdCategoria,
                        ca_Codigo = info.ca_Codigo,
                        ca_Descripcion = info.ca_Descripcion,
                        ca_Estado = true
                    });
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ModificarDB(Categoria_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Categoria Entity = db.Categoria.Where(q => q.IdCategoria == info.IdCategoria).FirstOrDefault();
                    if (Entity == null) return false;


                    Entity.ca_Codigo = info.ca_Codigo;
                    Entity.ca_Descripcion = info.ca_Descripcion;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool AnularDB(Categoria_Info info)
        {
            try
            {
                using (EntitiesGeneral db = new EntitiesGeneral())
                {
                    Categoria Entity = db.Categoria.Where(q => q.IdCategoria == info.IdCategoria).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.ca_Estado = false;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}