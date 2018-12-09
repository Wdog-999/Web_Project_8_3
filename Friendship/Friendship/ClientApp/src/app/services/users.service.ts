import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl = 'api/users/';

  constructor(private http: HttpClient, public jwtHelper: JwtHelperService) { }

  getUser(id: string) {
    return this.http.get(this.baseUrl + 'getuser?id=' + id);
  }

  getUsers() {
    return this.http.get(this.baseUrl + 'getusers');
  }
}
