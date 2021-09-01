import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserInfo } from 'src/app/shared/models/userModel';
import { environment } from 'src/environments/environment';
import {map} from 'rxjs/operators';
import { User } from 'src/app/shared/models/userDetails';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  GetAllUsers(): Observable<UserInfo[]>{
    return this.http.get(`${environment.apiUrl}`+'Users/getallusers')
    .pipe(
      map(resp => resp as UserInfo[])
    )
  }
  GetUserDetails(userId:number): Observable<User>{
    return this.http.get(`${environment.apiUrl}` + 'users/' + userId.toString())
    .pipe(
      map(resp => resp as User)
    )
  }
}
