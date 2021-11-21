import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PointService {
  private endpoint = `${environment.apiUrl}/points`;

  public constructor(
    private http: HttpClient
  ) { }

  public register() {
    return this.http.post(this.endpoint, {}).subscribe();
  }

  public getUserLastPoint() {
    return this.http.get(`${this.endpoint}/last`);
  }

  public getTodayPoints() {
    return this.http.get(`${this.endpoint}/today`);
  }
}
