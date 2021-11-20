import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public constructor(
    private authService: AuthService
  ) { }

  public get isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }

  public logout(): void {
    this.authService.signOut();
  }
}
