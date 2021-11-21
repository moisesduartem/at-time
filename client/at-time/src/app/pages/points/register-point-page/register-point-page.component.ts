import { Component, OnInit } from '@angular/core';
import { Point } from 'src/app/models/point.model';
import { PointService } from 'src/app/services/point.service';

@Component({
  selector: 'app-register-point-page',
  templateUrl: './register-point-page.component.html',
  styleUrls: ['./register-point-page.component.scss']
})
export class RegisterPointPageComponent implements OnInit {

  public lastPoint: Point | null = null;

  public constructor(
    private pointService: PointService
  ) { }

  public ngOnInit(): void {
    this.updateLastPoint();
  }

  public get hasLastPoint(): boolean {
    return !!this.lastPoint;
  }

  public registerPoint(): void {
    this.pointService.register();
    window.location.reload();
  }

  private updateLastPoint() {
    this.pointService.getUserLastPoint().subscribe((response: any) => {
      this.lastPoint = new Point(response);
    });
  }

}
