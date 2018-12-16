import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserDetails } from '../models/user-details';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl = 'api/users/';

  constructor(private http: HttpClient, public jwtHelper: JwtHelperService) { }

  getUser(id: string) {
    return this.http.get<UserDetails>(this.baseUrl + 'getuser?id=' + id, { headers: this.jwt() });
  }

  getUsers() {
    return this.http.get<UserDetails[]>(this.baseUrl + 'getusers', { headers: this.jwt() });
  }

  private jwt() {
    const token = localStorage.getItem('token');
    console.log(token);
    if (token) {
      let headers = new HttpHeaders({ 'Authorization': ' Bearer ' + token });
      console.log(headers);
      return headers;
    }
  } 
}
