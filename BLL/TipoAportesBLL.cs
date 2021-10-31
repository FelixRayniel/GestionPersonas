﻿using GestionPersonas.DAL;
using GestionPersonas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.BLL
{
   public  class TipoAportesBLL
    {
        public static bool Guardar(TipoAportes tipoAporte)
        {
            if (!Existe(tipoAporte.TipoAporteID))
            {
                return Insertar(tipoAporte);
            }
            else
            {
                return Modificar(tipoAporte);
            }
        }
        private static bool Insertar(TipoAportes tipoAporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.TiposAportes.Add(tipoAporte);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(TipoAportes tipoAporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(tipoAporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var tipoAporte = contexto.TiposAportes.Find(id);

                if (tipoAporte != null)
                {
                    contexto.TiposAportes.Remove(tipoAporte);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static TipoAportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TipoAportes tiposAporte;

            try
            {
                tiposAporte = contexto.TiposAportes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tiposAporte;
        }
        public static List<TipoAportes> GetList(Expression<Func<TipoAportes, bool>> criterio)
        {
            List<TipoAportes> lista = new List<TipoAportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TiposAportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.TiposAportes.Any(t => t.TipoAporteID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static bool ExisteDescripcion(string descripcion)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.TiposAportes.Any(r => r.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<TipoAportes> GetTiposAportes()
        {
            List<TipoAportes> lista = new List<TipoAportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TiposAportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
