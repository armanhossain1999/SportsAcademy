import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap } from 'rxjs';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { UploadResponse } from 'src/app/models/common/upload-response';
import { Course } from 'src/app/models/data/course';


@Injectable({
  providedIn: 'root'
})
export class CourseService {
  constructor(
    private http:HttpClient
  ) { }
  

  getCourses(): Observable<Course[]> {
    return this.http.get<Course[]>(`${apiBaseUrl}/api/Courses`)    
  }

  getCoursesWithPlayers(): Observable<Course[]> {
    return this.http.get<Course[]>(`${apiBaseUrl}/api/Courses/Players/Include`)    
  }
  getCoursesWithPlayerById(id:number): Observable<Course[]>
  {
    return this.http.get<Course[]>(`${apiBaseUrl}/api/Courses/Player/Include/${id}`)
  }
  create(data:Course):Observable<Course>{
    console.log(data)
    return this.http.post<Course>(`${apiBaseUrl}/api/Courses`, data);
  }
  update(data: Course): Observable<any> {
    return this.http.put<Course>(`${apiBaseUrl}/api/Courses/${data.courseId}`, data);
  }
  getById(id: number): Observable<Course> {
    return this.http.get<Course>(`${apiBaseUrl}/api/Courses/${id}`)
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/Courses/${id}`);
  }
}