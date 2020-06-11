import { environment } from "./../../environments/environment";
import { Injectable, EventEmitter } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { filter, take, map } from "rxjs/operators";

@Injectable({
  providedIn: "root",
})
export class ComplianceService {  
  constructor(private http: HttpClient) {}

  downloadFile(fileName: string) {
    return this.http
      .get(`${environment.API_URL}compliance/${fileName}`, {
        responseType: 'blob' as 'json',
      }).pipe(take(1));
  }
}
