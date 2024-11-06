public class Usuario{
    public string username{get;set;}
    public string password {get;set;}
    public string mail {get;set;}
    public string pregunta {get;set;}

public Usuario(){}

public Usuario(string pUsername, string pPassword, string pMail){
    username = pUsername;
    password = pPassword;
    mail = pMail;
}
}