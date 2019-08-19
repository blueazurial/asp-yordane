using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace WebApplication1.Mapper
{
    public static class MapperExtension
    {
        // Création d'une méthode d'extension pour tous les objets
        public static T Map<T>(this object o)
            // On s'assure que la classe T possede un constructeur vide
            where T : new()
        {
            // Récupération de toutes les propiétés de la class T
            PropertyInfo[] props = typeof(T).GetProperties();
            // Récupération du ctor de la class T
            ConstructorInfo ctor = typeof(T)
                .GetConstructor(new Type[0]);
            // instanciation d'un objet T
            T result = (T)ctor?.Invoke(new object[0]);
            // Parcourt toutes les propriétés de la class T
            foreach (var prop in props)
            {
                // Recherche d'une prop dans l'objet de départ qui possède un nom identique 
                var currentProp = o.GetType().GetRuntimeProperty(prop.Name);
                // si la propriété existe
                if (currentProp != null)
                {
                    // récupération de la valeur de cette prop dans l'objet de dédart
                    object value = currentProp.GetValue(o);

                    // affectation de cette valeur dans l'objet de destination T
                    prop.SetValue(result, value);
                }
            }
            return result;
        }
    }
}