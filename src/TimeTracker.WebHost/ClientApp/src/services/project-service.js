import axios from 'axios';

export class ProjectService {
  static fetchProjectsAsync() {
    return axios({
      method: 'POST',
      url: '/api/projects/list'
    });
  }

  static createProjectAsync(data) {
    return axios({
      method: 'POST',
      url: '/api/projects/new',
      data
    });
  }
}
