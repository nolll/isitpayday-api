<template>
    <div>
        <h3>Timezone</h3>
        <div class="timezone-info">
            <p v-show="showForm">
                <select v-model.number="timezone">
                    <option v-for="t in timezones" :value="t.id">{{t.id}}</option>
                </select>
                <a href="#" @click.prevent="close">Cancel</a>
            </p>
            <p v-show="!showForm">
                {{timezone}}
                <a href="#" @click.prevent="open">Change</a>
            </p>
        </div>
    </div>
</template>

<script>
    import { mapGetters } from 'vuex';

    export default {
        data: function () {
            return {
                showForm: false
            };
        },
        computed: {
            ...mapGetters(['timezones']),
            timezone: {
                get() {
                    return this.$store.getters.timezone;
                },
                set(value) {
                    this.$store.dispatch('selectTimezone', value);
                    this.close();
                }
            },
        },
        methods: {
            open: function () {
                this.showForm = true;
            },
            close: function () {
                this.showForm = false;
            }
        }
    };
</script>