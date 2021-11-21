import { MenuItem } from 'primeng/api';
import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  public items!: MenuItem[];

  public constructor(
    private authService: AuthService
  ) { }

  public ngOnInit(): void {
    this.items = [
      {
        label: 'Points',
        items: [
          {
            label: 'Register',
            routerLink: ['/points/register']
          }
        ]
      },
      {
        label: 'My Profile',
        routerLink: ['/me']
      },
      {
        label: 'Logout',
        command: () => this.logout()
      }
    ];
  }

  public logout(): void {
    this.authService.signOut();
  }

}
