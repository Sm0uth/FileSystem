using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Arborescence
{
    class File
    {
        //Variables
        public string Nom { get; set; }
        public Directory parent { get; set; }
        public int permission;

        //Constructeur
        public File(string nom, Directory parent)
        {
            this.Nom = nom;
            this.parent = parent;
            permission = 4;
        }

        //Methodes
        public bool canWrite()
        {
            return (permission & 2) > 0;
        }
        public bool canExecute()
        {
            return (permission & 1) > 0;
        }
        public bool canRead()
        {
            return (permission & 4) > 0;
        }
        public string getPermission()
        {
            string permission = "";
            if (this.canExecute())
            {
                permission = permission + "x";
            }
            else if (this.canRead())
            {
                permission = permission + "r";
            }
            else if (this.canWrite())
            {
                permission = permission + "w";
            }
            else
            {
                permission = permission + "-";
            }
            return permission;
        }

        public string getPath()
        {
            File courant = this;
            string path = "";
            while (courant.Nom!="/")
            {
                path = courant.Nom + "/" + path;
                courant = courant.parent;
            }
            return path;

        }
            //       Fichier pathFile = this;
            //string path = "";

            //while (pathFile.Nom != "/")
            //{

            //    path = pathFile.Nom + "/" + path;
            //    pathFile = pathFile.Parent;

            //}


        public File getRoot()
        {
            File courant = this;
            while (this.parent.Nom !="/" )
            {
                courant = this.parent;
                return courant;
            }
            return courant;
        }

        public bool renameTo(string newName) 
        {
            this.Nom = newName;
            if (Nom == newName)
                return true;
            else
                return false;
        }

        public File getParent()
        {
            File parentRetour = null;
            if (this.parent != null)
            {
                parentRetour = this.parent;
                return parentRetour;
            }
            else
            {
                Console.WriteLine("C'est déjà l'origine du monde");
                return this.parent;
            }
        }

        public bool isDirectory()
        {
            if (this.GetType() == typeof(Directory))
                return true;
            else
                return false;
        }


        public bool isFile() 
        {
            if (this.GetType() == typeof(File))
                return true;
            else
                return false;
        }

        public string getName() 
        {
            string nomFile = this.Nom;
            return nomFile;            
        }

        public void chmod(int permission)
        {
            this.permission = permission;
        }


    }
}
