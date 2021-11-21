import { Component, OnInit } from '@angular/core';
import { Point } from 'src/app/models/point.model';
import { PointService } from 'src/app/services/point.service';

@Component({
  selector: 'app-today-points-page',
  templateUrl: './today-points-page.component.html',
  styleUrls: ['./today-points-page.component.scss']
})
export class TodayPointsPageComponent implements OnInit {

  public points: Point[] = [];

  public constructor(
    private pointService: PointService
  ) { }

  public ngOnInit(): void {
    this.pointService.getTodayPoints().subscribe((response: any) => {
      this.points = response?.map((point: any) => new Point(point));
    });
  }

}
