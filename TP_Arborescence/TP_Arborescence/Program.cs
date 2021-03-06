﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Arborescence
{
    class Program
    {
        static void Main(string[] args)
        {
            File Courant = new Directory("/", null);
            Directory CourantDir=null;
            string SaisieUser = "";
            string utilisateur = "Benjamin_T";
            Console.WriteLine("Bienvenue dans ce splendide simulateur UNIX");
            Console.WriteLine("Veuillez saisir les commandes souhaitées.");
            Console.WriteLine("Pour quitter le simulateur, veuillez saisir exit.\n");

            while (SaisieUser != "exit") 
            {
                Console.Write("["+utilisateur+"] $ " + Courant.Nom + "/  ");
                SaisieUser = Console.ReadLine();
                string[] saisieSplit = SaisieUser.Split(' ');

                  if (Courant.isDirectory() == true){
                      CourantDir = (Directory)Courant;
                  }

                switch (saisieSplit[0])
 
                {
                    case "cd":
                        File fileCD = CourantDir.cd(saisieSplit[1]);
                        if (saisieSplit.Length == 1)
                        {
                            Console.WriteLine("Veuillez spécifier un dossier ou un fichier.");
                        }                        
                        else if (fileCD != null)
                        {
                            Courant = fileCD;
                        }
                        else
                            Console.WriteLine("Le déplacement n'est pas possible (Fichier inexistant)");
                        break;


                    case "ls":
                         if (CourantDir.canRead())
                            {
                                List<File> liste = CourantDir.ls();
                                if (Courant.isDirectory() == true)
                                {
                                    foreach (File file in liste)
                                    {
                                        Console.WriteLine(file.getPermission()+ " " + file.Nom);
                                    }
                                }
                                else if (Courant.isFile() == true)
                                {
                                    Console.WriteLine("Vous êtes dans un file");
                                }
                            }
                            else {
                                Console.WriteLine("Vous n'avez pas la permission");
                            }
                        break;


                    case "mkdir":
                        if (saisieSplit.Length >= 2) 
                        {
                            if (CourantDir.mkdir(saisieSplit[1]))
                            {
                                Console.WriteLine("Le dossier " + saisieSplit[1] + " est bien créé.");
                            }
                            else
                            {
                                Console.WriteLine("Echec de la création du dossier.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "path":
                        string path = Courant.getPath();
                        Console.WriteLine(path);
                        break;


                    case "root":
                        Courant = Courant.getRoot();
                        break;


                    case "rename":
                        if (saisieSplit.Length>=3)
                        {
                            if(Courant.renameTo(saisieSplit[2]))
                            {
                                Console.WriteLine("Le fichier ou dossier précisé a bien été renommé");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "create":
                        if (saisieSplit.Length >= 2)
                        {
                            if (CourantDir.createNewFile(saisieSplit[1]))
                            {
                                Console.WriteLine("Fichier bien créé.");
                            }
                            else
                            {
                                Console.WriteLine("Echec de la création.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "parent":
                        Courant = Courant.getParent();                        
                        break;

                    case "search":
                        if (saisieSplit.Length >= 2)
                        {
                            List<File> resultat = CourantDir.search(saisieSplit[1]);
                            if (resultat != null)
                            {
                                foreach (File file in resultat)
                                    Console.WriteLine(file.getPath());
                            }
                            else
                            {
                                Console.WriteLine("La recherche n'a pas abouti");
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "file":
                        if (Courant.isFile())
                        {
                            Console.WriteLine("Ceci est une file");
                        }
                        else
                        {
                            Console.WriteLine("Ceci n'est pas une file.");
                        }
                        break;


                    case "directory":
                        if (Courant.isDirectory())
                        {
                            Console.WriteLine("Ceci est un directory");
                        }
                        else
                        {
                            Console.WriteLine("Ceci n'est pas un directory");
                        }
                        break;


                    case "name":
                        Console.WriteLine("Le nom du fichier est " + Courant.getName());
                        break;


                    case "delete":
                        if (saisieSplit.Length >= 2)
                        {
                            if (CourantDir.delete(saisieSplit[1]))
                            {
                                Console.WriteLine("Fichier bien supprimé.");
                            }
                            else
                            {
                                Console.WriteLine("Echec de la supression.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }

                        break;


                    case "chmod":
                        if (saisieSplit.Length >= 2)
                        {
                            Courant.chmod(int.Parse(saisieSplit[1]));
                            Console.WriteLine("Modification de permission effectuée avec succès.");
                        }
                        else
                            Console.WriteLine("Veuillez saisir le degré de permission.");
                        break;

                    default:
                        Console.WriteLine("Commande erronée ou inconnue. Veuillez recommencer.");
                        break;
                }

            }

        }
    }
}