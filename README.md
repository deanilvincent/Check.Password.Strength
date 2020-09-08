# Overview
.NET package to check the password strength of a certain passphrase. A password strength checker based from `System.Text.RegularExpressions`.

[![Build Status](https://dev.azure.com/dv-github-repos/Check.Password.Strength/_apis/build/status/Check.Password.Strength-NET%20Core-CI?branchName=master)](https://dev.azure.com/dv-github-repos/Check.Password.Strength/_build/latest?definitionId=4&branchName=master)

## Installation
You can install using the following options:
**Package Manager**
```
Install-Package Check.Password.Strength
```
**.NET CLI**
```
dotnet add package Check.Password.Strength
```
**PackageReference**
```
<PackageReference Include="Check.Password.Strength" Version="1.0.2" />
```
**Paket CLI**
```
paket add Check.Password.Strength
```
## Setup & Basic Usage
```
using CheckPasswordStrength;

public class MyClass {
    public void Test(){
        var password = "mypassword";
        var passwordStrength = password.PasswordStrength();
        // properties
        // Id = 0, Value = "Weak", Length = 10 & contains = [{Message = "lowercase"}]
    }
}
```
## Additional Info

### Object 
| Property| Desc. |
| -- | -- |
| Id (int) | **0** = Weak, **1** = Medium & **2** = Strong |
| Value (string) | Weak, Medium & Strong |
| Contains (Collection) | lowercase, uppercase, symbol and/or number |
| Length (int) | length of the password |

### RegEx 

**Strong Password RegEx used:** 

 `^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})`

**Medium Password RegEx used:**  

`^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[!@#\$%\^&\*])|((?=.*[a-z])(?=.*[!@#\$%\^&\*])|((?=.*[0-9])(?=.*[!@#\$%\^&\*]))(?=.{6,})"`

|RegEx| Desc. |
|--|--|
| ^ | The password string will start this way |
| (?=.*[a-z]) | The string must contain at least 1 lowercase alphabetical character | 
|(?=.*[A-Z]) | The string must contain at least 1 uppercase alphabetical character
|(?=.*[0-9]) | The string must contain at least 1 numeric character
|(?=._[!@#\$%\^&_]) | The string must contain at least one special character, but we are escaping reserved RegEx characters to avoid conflict
| (?=.{8,}) | The string must be eight characters or longer

### Other info
If you're working with node.js environment, optionally, you use this package [check-password-password](https://www.npmjs.com/package/check-password-strength). This NPM package uses the same RegEx for checking password strength.

### Contribute

Feel free to clone or fork this project:  `https://github.com/deanilvincent/Check.Password.Strength.git`

Contributions & pull requests are welcome!

I'll be glad if you give this project a ★ on [Github](https://github.com/deanilvincent/Check.Password.Strength) :)

### License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/deanilvincent/Check.Password.Strength/blob/master/LICENSE) file for details.