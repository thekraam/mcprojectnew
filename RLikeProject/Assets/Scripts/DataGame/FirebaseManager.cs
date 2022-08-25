using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;



public class FirebaseManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;

    //Login variables
    [Header("Login")]
    public GameObject LoginPanel_LoginButton;
    public GameObject LoginPanel_RegisterButton;
    public InputField emailLoginField;
    public InputField passwordLoginField;
    public Text warningLoginText;
    public Text confirmLoginText;

    //Register variables
    [Header("Register")]
    public GameObject registerPanel;

    public InputField usernameRegisterField;
    public InputField emailRegisterField;
    public InputField passwordRegisterField;
    public InputField passwordRegisterVerifyField;
    public Text warningRegisterText;

    //User Data variables
    [Header("UserData")]
    public InputField usernameField;
    public Text username;
    public Text goldField;
    public TextMeshProUGUI seasonField;
    public Text citynameField;
    public GameObject scoreElement;
    public Transform scoreboardContent;



    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
        AuthStateChanged(this, null);

    }

    public bool isSignedIn()
    {
        bool signedIn = false;

        if (auth != null)
        {
            signedIn = (User == auth.CurrentUser) && (auth.CurrentUser != null);
        }

        return signedIn;
    }

    public void LogStatus(GameObject logStatus, GameObject userPanel)
    {
        if (!isSignedIn())
        {
            logStatus.SetActive(true);
            userPanel.SetActive(false);
            username.text = "";
        }
        else
        {
            logStatus.SetActive(false);
            userPanel.SetActive(true);
            StartCoroutine(userSigneIn());
            StopCoroutine(userSigneIn());
        }
    }

    private IEnumerator userSigneIn()
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            username.text = "0";
    
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            username.text = snapshot.Child("username").Value.ToString();
        }

        
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser != User) {
            bool signedIn = User != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && User != null) {
                Debug.Log("Signed out " + User.UserId);
            }
            User = auth.CurrentUser;
            if (signedIn) {
                Debug.Log("Signed in " + User.UserId);
                
            }
        }
    }

    public void ClearLoginFeilds()
    {
        emailLoginField.text = "";
        passwordLoginField.text = "";
    }
    public void ClearRegisterFeilds()
    {
        usernameRegisterField.text = "";
        emailRegisterField.text = "";
        passwordRegisterField.text = "";
        passwordRegisterVerifyField.text = "";
    }

    //Function for the login button
    public void LoginButton()
    {
        //Call the login coroutine passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    //Function for the register button
    public void RegisterButton()
    {
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }
    //Function for the sign out button
    public void SignOutButton()
    {
        auth.SignOut();
        ClearRegisterFeilds();
        ClearLoginFeilds();
    }


    public void LoadDataButton(bool newGame)
    {
        if (!isSignedIn())
            Debug.Log("Not Connected");
        else
        {
            if(!newGame)
                StartCoroutine(LoadUserData());
            else
            {
                StartCoroutine(LoadUserTutorial());
            }
        }
    }

 

    //Function for the save button
    public void SaveDataButton()
    {
        StartCoroutine(UpdateUsernameAuth(usernameField.text));
        //StartCoroutine(UpdateUsernameDatabase(username.text));

        StartCoroutine(UpdateGold(int.Parse(goldField.text)));
        StartCoroutine(UpdateSeason(seasonField.text));
        StartCoroutine(UpdateCityName(citynameField.text));

        StartCoroutine(UpdateTutorials(FindObjectOfType<Tutorial>().welcomeTutorial, 
                                       FindObjectOfType<Tutorial>().villageTutorial,
                                       FindObjectOfType<Tutorial>().farmTutorial,
                                       FindObjectOfType<Tutorial>().barracksTutorial,
                                       FindObjectOfType<Tutorial>().blacksmithTutorial,
                                       FindObjectOfType<Tutorial>().guildTutorial,
                                       FindObjectOfType<Tutorial>().mineTutorial,
                                       FindObjectOfType<Tutorial>().bonusTutorial));

    }
    public void SaveFireBase()
    {
        if(!isSignedIn())
            Debug.Log("Not Connected");
        else 
            SaveDataButton();

    }

    public void SaveUsername()
    {
        StartCoroutine(UpdateUsernameDatabase(usernameRegisterField.text));
        StartCoroutine(UpdateCityName(""));
        StartCoroutine(UpdateGold(0));
        StartCoroutine(UpdateSeason(""));
    }
    //Function for the scoreboard button
    public void ScoreboardButton()
    {
        StartCoroutine(LoadScoreboardData());
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.color = new Color32(170, 0, 0, 255);
            warningLoginText.text = "";
            confirmLoginText.color = new Color32(0, 130, 0, 255);
            confirmLoginText.text = "Logged In";
            StartCoroutine(LoadUserData());

            yield return new WaitForSeconds(2);

            
            username.color = new Color32(0, 130, 0, 255);

            //usernameField.text = User.DisplayName;
            //StartCoroutine(userSigneIn());
            FindObjectOfType<Game>().onTapForSave();

            confirmLoginText.text = "";
            ClearLoginFeilds();
            ClearRegisterFeilds();
        }
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            //If the username field is blank show a warning
            warningRegisterText.color = new Color32(170, 0, 0, 255);
            warningRegisterText.text = "Missing Username";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //If the password does not match show a warning
            warningRegisterText.color = new Color32(170, 0, 0, 255);
            warningRegisterText.text = "Password Does Not Match!";
        }
        else if (!_email.Contains("@gmail") || !_email.Contains("@libero") || !_email.Contains("@hotmail") || !_email.Contains("@outlook") || !_email.Contains("@icloud") || !_email.Contains("@yahoo") || !_email.Contains("@tiscali") || !_email.Contains("@stud") || !_email.Contains("@protonmail"))
        {
            //If mail provider is not supported
            warningRegisterText.color = new Color32(170, 0, 0, 255);
            warningRegisterText.text = "This e-mail provider is not supported";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.color = new Color32(170, 0, 0, 255);
                warningRegisterText.text = message;
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //If there are errors handle them
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        warningRegisterText.color = FindObjectOfType<Game>().darkred;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        
                        //Username is now set
                        //Now return to login screen
                        Debug.LogFormat("User register in successfully: {0} ({1})", User.DisplayName, User.Email);
                        registerPanel.SetActive(false);
                        LoginPanel_LoginButton.SetActive(true);
                        LoginPanel_RegisterButton.SetActive(true);
                        warningRegisterText.text = "";
                        SaveUsername();
                        FindObjectOfType<Game>().onTapForSave();
                        ClearRegisterFeilds();
                        ClearLoginFeilds();
                        SaveDataButton();
                    }
                }
            }
        }
    }

    private IEnumerator UpdateUsernameAuth(string _username)
    {
        //Create a user profile and set the username
        UserProfile profile = new UserProfile { DisplayName = _username };

        //Call the Firebase auth update user profile function passing the profile with the username
        var ProfileTask = User.UpdateUserProfileAsync(profile);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        if (ProfileTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
        }
        else
        {
            //Auth username is now updated
        }
    }

    private IEnumerator UpdateUsernameDatabase(string _username)
    {
        //Set the currently logged in user username in the database
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("username").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
            
        }
    }
    private IEnumerator UpdateCityName(string _cityname)
    {
        //Set the currently logged in user deaths
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("cityname").SetValueAsync(_cityname);
        
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Deaths are now updated
            
        }
    }

    private IEnumerator UpdateSeason(string _season)
    {
        //Set the currently logged in user kills
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("season").SetValueAsync(_season);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Season are now updated
        }
    }

    private IEnumerator UpdateGold(int _gold)
    {
        //Set the currently logged in user xp
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("gold").SetValueAsync(_gold);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Gold is now updated
        }
    }

    
    private IEnumerator UpdateTutorials(bool welcomeTutorial, bool villageTutorial, bool farmTutorial, bool barracksTutorial, bool blacksmithTutorial, bool guildTutorial, bool mineTutorial, bool bonusTutorial)
    {
        //Set the currently logged in tutorials
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("welcomeTutorial").SetValueAsync(welcomeTutorial);
        var DBTask1 = DBreference.Child("users").Child(User.UserId).Child("villageTutorial").SetValueAsync(villageTutorial);
        var DBTask2 = DBreference.Child("users").Child(User.UserId).Child("farmTutorial").SetValueAsync(farmTutorial);
        var DBTask3 = DBreference.Child("users").Child(User.UserId).Child("barracksTutorial").SetValueAsync(barracksTutorial);
        var DBTask4 = DBreference.Child("users").Child(User.UserId).Child("blacksmithTutorial").SetValueAsync(blacksmithTutorial);
        var DBTask5 = DBreference.Child("users").Child(User.UserId).Child("guildTutorial").SetValueAsync(guildTutorial);
        var DBTask6 = DBreference.Child("users").Child(User.UserId).Child("mineTutorial").SetValueAsync(mineTutorial);
        var DBTask7 = DBreference.Child("users").Child(User.UserId).Child("bonusTutorial").SetValueAsync(bonusTutorial);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted && DBTask1.IsCompleted && DBTask2.IsCompleted && DBTask3.IsCompleted && DBTask4.IsCompleted && DBTask5.IsCompleted && DBTask6.IsCompleted && DBTask7.IsCompleted);

        if (DBTask.Exception != null || DBTask1.Exception != null || DBTask2.Exception != null || DBTask3.Exception != null || DBTask4.Exception != null || DBTask5.Exception != null || DBTask6.Exception != null || DBTask7.Exception != null)
        {
            Debug.LogWarning("Load tutorial failed.");
        }
        else
        {
            //Gold is now updated
        }
    }

    public bool dataLoaded = false;
    public IEnumerator LoadUserData()
    {
        dataLoaded = false;
        //Get the currently logged in user data
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();


        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
            citynameField.text = "0";
            seasonField.text = "0";
            goldField.text = "0";
            
            
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            

            citynameField.text = snapshot.Child("cityname").Value.ToString();
            seasonField.text = snapshot.Child("season").Value.ToString();
            goldField.text = snapshot.Child("gold").Value.ToString();



            FindObjectOfType<Tutorial>().welcomeTutorial = snapshot.Child("welcomeTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().villageTutorial = snapshot.Child("villageTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().farmTutorial = snapshot.Child("farmTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().barracksTutorial = snapshot.Child("barracksTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().blacksmithTutorial = snapshot.Child("blacksmithTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().guildTutorial = snapshot.Child("guildTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().mineTutorial = snapshot.Child("mineTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().bonusTutorial = snapshot.Child("bonusTutorial").Value.ToString() == "False" ? false : true;

        }

        dataLoaded = true;
    }

    public IEnumerator LoadUserTutorial(){
        dataLoaded = false;
        //Get the currently logged in user data
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();


        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else if (DBTask.Result.Value == null)
        {
            //No data exists yet
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;


            FindObjectOfType<Tutorial>().welcomeTutorial = snapshot.Child("welcomeTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().villageTutorial = snapshot.Child("villageTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().farmTutorial = snapshot.Child("farmTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().barracksTutorial = snapshot.Child("barracksTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().blacksmithTutorial = snapshot.Child("blacksmithTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().guildTutorial = snapshot.Child("guildTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().mineTutorial = snapshot.Child("mineTutorial").Value.ToString() == "False" ? false : true;
            FindObjectOfType<Tutorial>().bonusTutorial = snapshot.Child("bonusTutorial").Value.ToString() == "False" ? false : true;

        }
        dataLoaded = true;
    }


    private IEnumerator LoadScoreboardData()
    {
        //Get all the users data ordered by kills amount
        var DBTask = DBreference.Child("users").OrderByChild("gold").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            //Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                
                string username = childSnapshot.Child("username").Value.ToString();
                string cityname = childSnapshot.Child("cityname").Value.ToString();
                string season = childSnapshot.Child("season").Value.ToString();
                string gold = childSnapshot.Child("gold").Value.ToString();

                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, cityname, gold, season);
            }

        }
    }
    
}
