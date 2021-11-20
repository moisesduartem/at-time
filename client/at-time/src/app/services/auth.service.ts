import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginRequest } from '../requests/login.request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public endpoint = 'http://localhost:5001/auth';
  public headers = new HttpHeaders().set('Content-Type', 'application/json');
  public currentUser = {};

  constructor(private http: HttpClient, public router: Router) { }

  public signUp(user: User): Observable<any> {
    return this.http.post(this.endpoint + '/auth/register', user).pipe(
      catchError(this.handleError)
    );
  }

  public signIn(body: LoginRequest) {
    return this.http.post(this.endpoint + '/auth/login', body)
      .subscribe((response: any) => {
        localStorage.setItem('at-time:token', response.token);
        localStorage.setItem('at-time:user', response.user);
      })
  }

  public get authenticatedUser(): User | null {
    try {
      return JSON.parse(localStorage.getItem('at-time:user') || '');
    } catch {
      return null;
    }
  }

  public get token() {
    return localStorage.getItem('at-time:token');
  }

  public get isLoggedIn(): boolean {
    return Boolean(this.token);
  }

  private handleError(error: HttpErrorResponse) {
    let message = '';

    if (error.error instanceof ErrorEvent) {
      message = error.error.message;
    } else {
      message = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }

    return throwError(message);
  }

}