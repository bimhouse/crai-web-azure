import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Portfolio, Fields } from '../crai-work/Portfolio';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CraiWorkService {

  constructor(protected http: HttpClient, @Inject('BASE_URL') protected baseUrl: string) { }

  getData(): Observable<Portfolio> {
    var url = this.baseUrl + 'api/Projects';

    return this.http.get<Portfolio>(url);
  }

  getDetail(id: string) {
    var url = this.baseUrl + 'api/Projects/' + id;

    return this.http.get<Portfolio>(url);
  }
   

}
