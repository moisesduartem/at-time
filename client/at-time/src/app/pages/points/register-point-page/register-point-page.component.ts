import { Component, OnInit } from '@angular/core';
import { PointService } from 'src/app/services/point.service';

@Component({
  selector: 'app-register-point-page',
  templateUrl: './register-point-page.component.html',
  styleUrls: ['./register-point-page.component.scss']
})
export class RegisterPointPageComponent implements OnInit {

  public constructor(
    private pointService: PointService
  ) { }

  public ngOnInit(): void {
  }

  public registerPoint(): void {
    this.pointService.register();
  }

}
