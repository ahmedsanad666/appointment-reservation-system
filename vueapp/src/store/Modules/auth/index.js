import actions from "./actions";
import mutations from "./mutations";
import getters from "./getters";

export default{
    namespaced:true,
    state(){
        return{
            userId:'asdf',
            token:'asdf',
        }
    },
    actions,
    mutations,
    getters
}