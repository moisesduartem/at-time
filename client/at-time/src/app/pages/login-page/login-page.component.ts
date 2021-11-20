import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  public signInForm: FormGroup;

  public constructor(
    public formBuilder: FormBuilder,
    public authService: AuthService,
    public router: Router) {
    this.signInForm = this.formBuilder.group({
      email: [''],
      password: ['']
    });
  }

  public ngOnInit(): void {
  }

  public signIn() {
    this.authService.signIn(this.signInForm.value);
  }

}
