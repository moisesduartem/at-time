import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public constructor(
    private authService: AuthService,
    private primeNgConfig: PrimeNGConfig
  ) { }

  public ngOnInit(): void {
    this.primeNgConfig.ripple = true;
  }

  public get isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }
}
