import { Component, Vue } from 'vue-property-decorator';
import { PaydayRequest } from './types/PaydayRequest';

@Component
export class StoreMixin extends Vue {

    protected get $_isReady(): boolean{
        return this.$store.getters['isReady'];
    }

    protected get $_isPayday(): boolean{
        return this.$store.getters['isPayday'];
    }

    protected get $_localTime(): Date{
        return this.$store.getters['localTime'];
    }

    protected get $_payday(): number{
        return this.$store.getters['payday'];
    }

    protected $_loadPayday(data: PaydayRequest) {
        this.$store.dispatch('loadPayday', data);
    }

    protected $_selectPayday(id: number){
        this.$store.dispatch('selectPayday', id);
    }

    $store: any;
}
