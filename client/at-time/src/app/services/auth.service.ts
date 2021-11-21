import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoginRequest } from '../requests/login.request';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public endpoint = `${environment.apiUrl}/auth`;
  public headers = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient, public router: Router) { }

  public signUp(user: User): Observable<any> {
    return this.http.post(this.endpoint + '/register', user).pipe(
      catchError(this.handleError)
    );
  }

  public signIn(body: LoginRequest, callback: () => void) {
    return this.http.post(this.endpoint + '/login', body)
      .pipe(catchError((error: HttpErrorResponse) => {
        callback();
        return this.handleError(error);
      }))
      .subscribe((response: any) => {
        localStorage.setItem('at-time:token', response.token);
        localStorage.setItem('at-time:user', JSON.stringify(response.user));
        this.router.navigate(['me']);
        callback();
      });
  }

  public signOut(): void {
    localStorage.removeItem('at-time:token');
    localStorage.removeItem('at-time:user');
    this.router.navigate(['login']);
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
    return !!this.token && !!this.authenticatedUser;
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
