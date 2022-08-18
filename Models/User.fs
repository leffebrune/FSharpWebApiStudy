namespace FSharpWebApiStudy.Models


type public UserModel(nickname : string) = class
    member this.Id = ""
    member val Nickname = nickname with get
    member val Stamina = 0 with get, set
end
    
