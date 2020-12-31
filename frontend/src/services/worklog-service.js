import axios from 'axios';

export class WorklogService {
  static startAsync(identifier, startDate) {
    return axios({
      method: 'POST',
      url: '/api/issue/startlog',
      data: {
        start: startDate,
        identifier
      }
    });
  }

  static stopAsync(identifier, endDate) {
    return axios({
      method: 'POST',
      url: '/api/issue/stoplog',
      data: {
        end: endDate,
        identifier
      }
    });
  }

  static addAsync() {}
  static removeAsync() {}
}
