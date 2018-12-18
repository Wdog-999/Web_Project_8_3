import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginVM } from '../login-vm';
import { AuthUser } from '../models/authUser';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { RegisterVM } from '../register-vm';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'api/auth/';

  constructor(private http: HttpClient, public jwtHelper: JwtHelperService) { }

  postLogin(loginVM: LoginVM) {
    return this.http.post(this.baseUrl + 'login', loginVM);
  }

  login(loginVM: LoginVM) {
    return this.http.post<AuthUser>('api/auth/login', loginVM)
      .pipe(map((result: AuthUser) => {
        if (result) {
          localStorage.setItem('token', result.tokenString);
          localStorage.setItem('user', JSON.stringify(result.user));
        }
        console.log(this.jwtHelper.isTokenExpired(result.tokenString));
        console.log(this.jwtHelper.getTokenExpirationDate(result.tokenString));
        return result;
      }));
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    console.log("At least the button works.");
  }

  postRegister(loginVM: RegisterVM) {
    /*var success =*/ return this.http.post(this.baseUrl + 'register', loginVM);
    //if (success) {
    //  var newUser: LoginVM = { UserName: loginVM.UserName, Password: loginVM.Password };
    //  console.log(newUser);
    //  return this.login(newUser);
    //}
  }

  public isAuthenticated(): boolean {

    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
  
}
