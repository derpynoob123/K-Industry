using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameAccess : MonoBehaviour {

    //References
    public List<string> DaysOfWeek = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    //EncryptFormat (without main keys {Format; ScrambleType}): TILAPNUS -> Default Password; 0 = date1; 1= date2; 2 = month1; 3 = month2; 4 = year1; 5 = year2; 6 = year3; 7 = year4;
    public List<string> ActualFormatList = new List<string> { "T0I1L2A3P4N5U6S7", "TILAP01234567NUS", "7654NUS32PALIT10", "TILAPNUS01234567", "AP01NUS23TIL4567", "32TIL01NUS76AP45", "47NUSAP56TIL1032" };
    public List<string> TheAlphabets = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    public List<string> EncryptAlphabetsTypeC = new List<string> { "8", "5", "2", "s", "k", "h", "c", "7", "l", "b", "z", "w", "a", "j", "1", "i", "p", "u", "n", "f", "t", "4", "v", "d", "e", "6", "x", "3", "g", "9", "y", "m", "q", "r", "o", "0" };
    public List<string> EncryptAlphabetsTypeO = new List<string> { "e", "4", "k", "o", "8", "c", "h", "n", "a", "q", "7", "1", "d", "u", "r", "j", "2", "g", "b", "m", "w", "6", "x", "t", "9", "i", "y", "5", "z", "v", "0", "l", "f", "s", "3", "p" };
    public List<string> EncryptAlphabetsTypeM = new List<string> { "x", "r", "g", "2", "o", "8", "5", "w", "l", "u", "m", "i", "y", "t", "4", "d", "f", "0", "p", "q", "3", "1", "c", "h", "s", "b", "9", "e", "7", "j", "z", "6", "a", "n", "k", "v" };
    public List<string> EncryptAlphabetsTypeB = new List<string> { "k", "s", "4", "8", "x", "a", "b", "7", "r", "p", "n", "t", "e", "v", "c", "o", "m", "y", "i", "z", "5", "g", "j", "w", "2", "d", "f", "9", "1", "q", "h", "0", "3", "6", "1", "u" };
    public List<string> EncryptAlphabetsTypeI = new List<string> { "1", "a", "d", "5", "y", "o", "3", "w", "s", "g", "t", "m", "2", "4", "f", "x", "b", "u", "h", "c", "r", "6", "e", "z", "k", "l", "j", "0", "p", "q", "8", "i", "v", "7", "9", "n" };
    public List<string> EncryptAlphabetsTypeN = new List<string> { "t", "m", "q", "z", "6", "3", "k", "l", "e", "p", "n", "1", "b", "2", "f", "8", "5", "u", "4", "o", "9", "r", "j", "w", "g", "a", "s", "i", "x", "d", "v", "0", "y", "c", "h", "7" };
    public List<string> EncryptAlphabetsTypeE = new List<string> { "h", "2", "p", "b", "u", "v", "t", "1", "0", "k", "y", "7", "q", "r", "4", "n", "5", "9", "a", "i", "z", "j", "c", "f", "m", "o", "8", "d", "l", "6", "g", "3", "s", "x", "w", "e" };

    public List<string> EncryptDaysOfWeek = new List<string> { "E", "N", "C", "R", "Y", "P", "T" };
    public List<string> EncryptionType = new List<string> { "C", "O", "M", "B", "I", "N", "E" };

    //Create Variables
    string Password;

    //References
    public GameObject IncorrectText;
    public GameObject InputObject;

    const string scene = "StartScreen";

    // Use this for initialization
    void Start()
    {

    }

    public string DecryptPassword(string TypedPassword)
    {
        var EncryptedPassword = "";
        var ProperFormat = "TILAPNUS01234567";

        var DecryptedPassword = ""; //Decrypt Password [NOT with correct format]
        var FinalDecryptedPassword = ""; //Final Decrypted Password [With correct format]

        var ValidLetters = true;

        //Remove - symbol
        for (var i = 0; i < TypedPassword.Length; i++)
        {
            if (TypedPassword[i].ToString() != "-")
            {
                EncryptedPassword += TypedPassword[i];
            }
        }

        //Check if encryptpassword contains caps or symbols in encrypted password[Can Take from any encryption]
        for (var i = 1; i < EncryptedPassword.Length - 1; i++)
        {
            if (!EncryptAlphabetsTypeC.Contains(EncryptedPassword[i].ToString()))
            {
                ValidLetters = false;
            }
        }

        //Check if Correct Length
        if (ValidLetters == true)
        {
            Debug.Log(ActualFormatList[0].Length);
            if (EncryptedPassword.Length - 2 == ActualFormatList[0].Length)
            {
                //Decrypt encryption type by looking at last char
                var LastCharEncryptPassword = EncryptedPassword[EncryptedPassword.Length - 1].ToString();
                if (EncryptionType.Contains(LastCharEncryptPassword))
                {
                    var DecryptionType = (List<string>)this.GetType().GetField("EncryptAlphabetsType" + LastCharEncryptPassword).GetValue(this);

                    //Decrypt the content ONLY (Check pos 1 to the pos before the last position)
                    for (var i = 1; i < EncryptedPassword.Length - 1; i++)
                    {
                        var pos = DecryptionType.IndexOf(EncryptedPassword[i].ToString());

                        var DecryptedLetter = TheAlphabets[pos];

                        DecryptedPassword += DecryptedLetter;
                    }
                    //Debug.Log("DecryptedPassword: " + DecryptedPassword.ToString());
                    //Check format by looking at first char
                    var FirstCharEncryptPassword = EncryptedPassword[0].ToString();
                    if (EncryptDaysOfWeek.Contains(FirstCharEncryptPassword))
                    {
                        var FormatTypePos = EncryptDaysOfWeek.IndexOf(FirstCharEncryptPassword);

                        var UsedFormatType = ActualFormatList[FormatTypePos];

                        //Reformat Password
                        var PositionOfFinalDecryptedPassword = 0;
                        //var PositionOfUsedFormatType = 0; //To ensure if the player did not type correctly
                        var DidNotFoundLetterInDecryptedPassword = false;

                        //Debug.Log("UsedFormatTypePos: " + UsedFormatTypePos.ToString());
                        while (PositionOfFinalDecryptedPassword < ProperFormat.Length)
                        {
                            if (DidNotFoundLetterInDecryptedPassword == false)
                            {
                                //Debug.Log("PositionOfUsedFormatType: " + PositionOfUsedFormatType.ToString());
                                //Debug.Log("PositionOfFinalDecryptedPassword: " + PositionOfFinalDecryptedPassword.ToString());
                                var FoundTheLetter = false;

                                for (var i = 0; i < UsedFormatType.Length; i++)
                                {
                                    //Debug.Log("i: " + i.ToString());
                                    //Debug.Log("PositionOfFinalDecryptedPassword: " + PositionOfFinalDecryptedPassword.ToString());
                                    if (FoundTheLetter == false)
                                    {
                                        if (ProperFormat[PositionOfFinalDecryptedPassword] == UsedFormatType[i])
                                        {
                                            //Debug.Log("i: " + i.ToString());
                                            //Debug.Log("PositionOfFinalDecryptedPassword: " + PositionOfFinalDecryptedPassword.ToString());
                                            //Debug.Log("ProperFormat: " + ProperFormat[PositionOfFinalDecryptedPassword].ToString());
                                            //Debug.Log("UsedFormatTypePos: " + UsedFormatType[i].ToString());
                                            FinalDecryptedPassword += DecryptedPassword[i];
                                            //Debug.Log("FinalDecryptedPassword: " + FinalDecryptedPassword.ToString());
                                            PositionOfFinalDecryptedPassword++;
                                            //PositionOfUsedFormatType = 0;
                                            //Debug.Log("PositionOfUsedFormatType: " + PositionOfUsedFormatType.ToString());
                                            FoundTheLetter = true;
                                        }
                                        else
                                        {
                                            //PositionOfUsedFormatType++;
                                        }
                                    }
                                }

                                if (FoundTheLetter == false)
                                {
                                    DidNotFoundLetterInDecryptedPassword = true;
                                }
                            }
                            else
                            {
                                PositionOfFinalDecryptedPassword = ProperFormat.Length;
                                //Debug.Log("FinalDecryptedPassword Length: " + FinalDecryptedPassword.Length.ToString());
                                if (FinalDecryptedPassword.Length != ProperFormat.Length)
                                {
                                    FinalDecryptedPassword = "Incorrect: Wrong Start Characters";
                                }
                            }
                        }
                    }
                    else
                    {
                        FinalDecryptedPassword = "Incorrect: Wrong First Char";
                    }
                }
                else
                {
                    FinalDecryptedPassword = "Incorrect: Wrong Last Char";
                }
            }
            else
            {
                FinalDecryptedPassword = "Incorrect: Length";
            }
        }
        else
        {
            FinalDecryptedPassword = "Incorrect: Not Valid Characters";
        }

        return FinalDecryptedPassword;
    }

    public void CheckPassword()
    {
        string InputtedPassword = InputObject.GetComponent<InputField>().text;

        var DecryptedInputtedPassword = DecryptPassword(InputtedPassword);
        Debug.Log("DecryptedInputtedPassword: " + DecryptedInputtedPassword.ToString());

        var ActualDate = System.DateTime.Now.ToString("ddMMyyyy");

        var CorrectPassword = "TILAPNUS" + ActualDate;
        Debug.Log("CorrectPassword: " + CorrectPassword);

        if (DecryptedInputtedPassword == CorrectPassword)
        {
            GoToScene(scene); //If user entered correct password, put the scene name
        }
        else
        {
            IncorrectPassword(); //If user has entered the wrong password
        }
    }

    void GoToScene(string SceneName)
    {
        if (Application.CanStreamedLevelBeLoaded(SceneName))
        {
            Debug.Log("Scene exists, loading...");
            SceneManager.LoadScene(SceneName);
        }
        else
        {
            Debug.Log("Scene does not exist");
        }
    }

    void IncorrectPassword()
    {
        IncorrectText.SetActive(true);
    }
    public void HideIncorrectText()
    {
        IncorrectText.SetActive(false);
    }
}
