import axios from 'axios';


export class IssueService {
    static createAsync(data) {
        return axios({
            method: 'POST',
            url: '/api/issue/new',
            data
        })
    }

    static getListAsync(data) {
        return axios({
            method: 'POST',
            url: '/api/issue/list',
            data
        });
    }
}
