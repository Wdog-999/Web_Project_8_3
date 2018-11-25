import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginVM } from '../login-vm';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'api/auth/';

  constructor(private http: HttpClient) { }

  postLogin(loginVM: LoginVM) {
    return this.http.post(this.baseUrl + 'login', loginVM);
  }

  postRegister(loginVM: LoginVM) {
    return this.http.post(this.baseUrl + 'register', loginVM);
  }

  
}
