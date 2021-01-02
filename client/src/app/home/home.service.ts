
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination, Pagination } from '../shared/models/pagination';
import { PostParams } from '../shared/models/postParams';
import { map } from 'rxjs/operators';
import { IPost } from '../shared/models/post';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  baseUrl = environment.apiUrl;
  
  pagination = new Pagination();
  postParams = new PostParams();
  posts: IPost[] = [];

  constructor(private http: HttpClient) {}

  // tslint:disable-next-line: typedef
  getPosts() {

   
    let params = new HttpParams();
   
    if (this.postParams.search) {
      params = params.append('search', this.postParams.search);
    }
    params = params.append('sort', this.postParams.sort);
    params = params.append('pageIndex', this.postParams.pageNumber.toString());
    params = params.append('pageSize', this.postParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'post', { observe: 'response', params })
      .pipe(
        map(response => {
          this.posts = response.body.data; 
          console.log(this.posts);
          this.pagination = response.body;
          return this.pagination;
        })
      );
  }

  getPostParams() {
    return this.postParams;
  }
   // tslint:disable-next-line: typedef
   setPostParams(params: PostParams) {
    this.postParams = params;
  }


}
