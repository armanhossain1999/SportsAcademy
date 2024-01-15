import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, tap } from 'rxjs';
import { apiBaseUrl } from 'src/app/shared/app-constants';
import { TrainingSession } from 'src/app/models/data/trainingSession';


@Injectable({
  providedIn: 'root'
})
export class TrainingSessionService {
  constructor(
    private http:HttpClient
  ) { }
  

  getTrainingSessions(): Observable<TrainingSession[]> {
    return this.http.get<TrainingSession[]>(`${apiBaseUrl}/api/TrainingSessions`)    
  }

  getTrainingSessionPlayers(): Observable<TrainingSession[]> {
    return this.http.get<TrainingSession[]>(`${apiBaseUrl}/api/TrainingSessions/Players/Include`)    
  }
  getTrainingSessionWithPlayerById(id:number): Observable<TrainingSession[]>
  {
    return this.http.get<TrainingSession[]>(`${apiBaseUrl}/api/TrainingSessions/Player/Include/${id}`)
  }
  create(data:TrainingSession):Observable<TrainingSession>{
    console.log(data)
    return this.http.post<TrainingSession>(`${apiBaseUrl}/api/TrainingSessions`, data);
  }
  update(data: TrainingSession): Observable<any> {
    return this.http.put<TrainingSession>(`${apiBaseUrl}/api/TrainingSessions/${data.trainingSessionId}`, data);
  }
  getById(id: number): Observable<TrainingSession> {
    return this.http.get<TrainingSession>(`${apiBaseUrl}/api/TrainingSessions/${id}`)
  }
  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${apiBaseUrl}/api/TrainingSessions/${id}`);
  }
}