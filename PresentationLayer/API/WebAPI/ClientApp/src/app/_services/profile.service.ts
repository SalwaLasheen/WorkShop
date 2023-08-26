import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

const baseUrl = `${environment.apiUrl}/ProfileStatus/CallWsdlApiAsync`;
//
let headers = new Headers();
headers.append('appVersion','1.1');
headers.append('osversion','1.7.1');
headers.append('isAndroid','true');

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  
  createNewProfile(params: any): Observable<any> {

    return this.http.post<any>(baseUrl, params,
      {headers: {'appVersion': '1.1', 'osversion':'1.7.1','isAndroid':'true'}})
    .pipe(catchError(err => {
      return throwError(err);
    }));
}
}
