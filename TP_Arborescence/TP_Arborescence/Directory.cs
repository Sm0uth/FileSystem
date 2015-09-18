using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Arborescence
{
    class Directory:File
    {
        //Variables
        List<File> listeFiles;

        //Constructeur
        public Directory(string nom, Directory parent): base (nom, parent)
        {
            this.Nom = nom;
            listeFiles = new List<File>();
            permission = 4;
        }

        //Méthodes
        public bool mkdir(string name)
        {
            listeFiles.Add(new Directory(name, this));
            if (listeFiles.Last().Nom == name)
                return true;
            else
                return false;
        }

        public List<File> ls() 
        {
                return this.listeFiles;

        }

        public bool createNewFile(string name)
        {
            listeFiles.Add(new File(name, this));
            if (listeFiles.Last().Nom == name)
                return true;
            else
                return false;
        }

        public bool delete(string name)
        {
            foreach (File file in listeFiles) 
            {
                if (file.Nom == name)
                {
                    listeFiles.Remove(file);
                    return true;
                }
                else
                    return false;
            }
            return false;
        }


        public File cd(string name)
        {
            File courantRemplacer = null;
            foreach (File file in listeFiles)
            {
                if (file.Nom == name)
                {
                    courantRemplacer = file;
                }
            }
            return courantRemplacer;
        }

        public List<File> search(string name)
        {
            List<File> retour = null;


            retour = new List<File>();

            foreach (File searchDir in listeFiles)
            {

                if (searchDir.Nom == name)
                {
                    retour.Add(searchDir);
                }


                List<File> retour2 = new List<File>();
                Directory searchDir2 = (Directory)searchDir;
                retour2 = searchDir2.search(name);
                foreach (File courant in retour2)
                {
                    retour.Add(courant);
                }
            }
            return retour;
        }
    }
}
