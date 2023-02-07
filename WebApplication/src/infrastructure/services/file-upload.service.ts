import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Observer } from 'rxjs';
import { Configuration } from '../configuration/configuration';
import { AttachedFile } from '../models/attached-file.model';
import { map } from "rxjs/operators";

@Injectable()
export class FileUploadService {
  constructor(private http: HttpClient, private configuration: Configuration) { }

  public uploadFile(url: string, file: File): Observable<AttachedFile> {
    return new Observable((observer: Observer<AttachedFile>) => {
      const formData = new FormData();
      const xhr = new XMLHttpRequest();

      formData.append('file', file);
      xhr.open('POST', url, true);
      xhr.setRequestHeader('X-Requested-With', 'XMLHttpRequest');
      xhr.send(formData);

      xhr.onreadystatechange = () => {
        if (xhr.readyState === 4) {
          if (xhr.status === 200) {
            observer.next(JSON.parse(xhr.response));
            observer.complete();
          } else {
            observer.error(xhr.response);
          }
        }
      };
    });
  }

  getBase64ImageUrl(key: string, dbId: number): Observable<string> {
    return this.http.get<string>(`${this.configuration.restUrl}/filesStorage/image?key=${key}&dbId=${dbId}`);
  }

  getStudentDiplomaFile(fileUrl: string, mimeType: string): Observable<Blob> {
    return this.http.get(fileUrl,
      { responseType: 'blob' })
      .pipe(
        map(response => new Blob([response], { type: mimeType }))
      );
  }
}
